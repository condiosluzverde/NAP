(function () {
    'use strict';

    angular
        .module('app')
        .controller('userAccountsController', userAccountsController);

    userAccountsController.$inject = ['$location']; 

    function userAccountsController($location) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'userAccountsController';

        activate();

        function activate() { }
    }
})();
