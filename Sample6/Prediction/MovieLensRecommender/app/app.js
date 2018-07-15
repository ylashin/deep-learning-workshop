(function () {

    'use strict';

    var app = angular
        .module('app', ['ui.router', 'angular-rating'])
        .config(config);

    config.$inject = [
        '$stateProvider',
        '$locationProvider',
        '$urlRouterProvider'
    ];

    function config(
        $stateProvider,
        $locationProvider,
        $urlRouterProvider       
    ) {

        $stateProvider
            .state('home', {
                url: '/',
                controller: 'HomeController',
                templateUrl: 'app/home/home.html',
                controllerAs: 'vm'
            });       

        $urlRouterProvider.otherwise('/');

        $locationProvider.hashPrefix('');

        $locationProvider.html5Mode(true);
    }
})();
