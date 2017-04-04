angular.module('project', ['ngRoute', 'firebase'])

.value('fbURL', 'https://ng-projects-list.firebaseio.com/')
.service('fbRef', function (fbURL) {
    return new Firebase(fbURL)
})
.service('fbAuth', function ($q, $firebase, $firebaseAuth, fbRef) {
    var auth;
    return function () {
        if (auth) return $q.when(auth);
        var authObj = $firebaseAuth(fbRef);
        if (authObj.$getAuth()) {
            return $q.when(auth = authObj.$getAuth());
        }
        var deferred = $q.defer();
        authObj.$authAnonymously().then(function (authData) {
            auth = authData;
            deferred.resolve(authData);
        });
        return deferred.promise;
    }
})

.service('Projects', function ($q, $firebase, fbRef, fbAuth, projectListValue) {
    var self = this;
    this.fetch = function () {
        if (this.projects) return $q.when(this.projects);
        return fbAuth().then(function (auth) {
            var deferred = $q.defer();
            var ref = fbRef.child('projects-fresh/' + auth.auth.uid);
            var $projects = $firebase(ref);
            ref.on('value', function (snapshot) {
                if (snapshot.val() === null) {
                    $projects.$set(projectListValue);
                }
                self.projects = $projects.$asArray();
                deferred.resolve(self.projects);
            });

            //Remove projects list when no longer needed.
            ref.onDisconnect().remove();
            return deferred.promise;
        });
    };
})

.config(function ($routeProvider) {
    var resolveUserAccounts = {
        userAccounts: function (UserAccounts) {
            return UserAccounts.fetch();
        }
    };

    $routeProvider
      .when('/', {
          controller: 'UserAccountListController as userAccountList',
          templateUrl: 'list.html',
          resolve: resolveUserAccounts
      })
      .when('/edit/:userAccountId', {
          controller: 'EditUserAccountController as editUserAccount',
          templateUrl: 'detail.html',
          resolve: resolveUserAccounts
      })
      .when('/new', {
          controller: 'NewUserAccountController as editUserAccount',
          templateUrl: 'detail.html',
          resolve: resolveUserAccounts
      })
      .otherwise({
          redirectTo: '/'
      });
})

.controller('UserAccountController', function (userAccounts) {
    var userAccountList = this;
    userAccountList.userAccounts = userAccounts;
})

.controller('NewUserAccountController', function ($location, userAccounts) {
    var editUserAccount = this;
    editUserAccount.save = function () {
        userAccounts.$add(editUserAccount.userAccount).then(function (data) {
            $location.path('/');
        });
    };
})

.controller('EditUserAccountController',
  function ($location, $routeParams, userAccounts) {
      var editUserAccount = this;
      var userAccountId = $routeParams.userAccountId,
          userAccountIndex;

      editUserAccount.userAccounts = userAccounts;
      userAccountIndex = editUserAccount.userAccounts.$indexFor(userAccountId);
      editUserAccount.userAccount = editUserAccount.userAccounts[userAccountIndex];

      editUserAccount.destroy = function () {
          editUserAccount.userAccounts.$remove(editUserAccount.userAccount).then(function (data) {
              $location.path('/');
          });
      };

      editUserAccount.save = function () {
          editUserAccount.userAccounts.$save(editUserAccount.project).then(function (data) {
              $location.path('/');
          });
      };
  });