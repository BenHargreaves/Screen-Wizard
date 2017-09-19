(function () {

    angular.module('ScreenWizard')

        .controller('ListScreenCtrl', function ($scope, $http, CollectionService) {
            var table = CollectionService.getTable();
            $scope.table = table;


        });

})();