(function () {


    angular.module('ScreenWizard')

        .controller('MainCtrl', function ($scope, $http, $location, CollectionService) {
            
           $scope.$parent.title = '';

            $scope.setScreenType = function(type) {
                CollectionService.setScreenType(type)
                $scope.$parent.title = type;
                $location.path("/TableSelect");
            };
        });




})();