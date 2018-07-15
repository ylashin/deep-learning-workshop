(function () {

    'use strict';

    angular
        .module('app')
        .controller('HomeController', homeController);

    homeController.$inject = [ '$scope', '$http', '$timeout'];

    function homeController($scope, $http, $timeout) {

        var vm = this;      
        vm.minRatings = 10;

        vm.activate = function () {

            $http.get("/api/movies/users/min-rating/" + vm.minRatings).then(function (result) {
                vm.users = result.data;
                $timeout(function () {
                    vm.selectedUser = vm.users[0].UserId;
                    vm.userChanged();
                });

            });
        }              

        vm.userChanged = function ()
        {
            if (!vm.selectedUser)
            {
                vm.ratings = [];
                return;
            }
            $http.get("/api/movies/users/ratings/" + vm.selectedUser).then(function (result) {
                vm.ratings = result.data;
            });
        }

        vm.predict = function (movie) {
            if (!vm.selectedUser) {                
                return;
            }
            $http.get("/api/movies/predict/" + movie.MovieId + "/" + vm.selectedUser ).then(function (result) {
                movie.prediction= result.data;
            });
        }

        vm.activate(); 
    }

})();