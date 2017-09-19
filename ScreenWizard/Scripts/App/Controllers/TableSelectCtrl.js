(function () {


    angular.module('ScreenWizard')

        .controller('TableSelectCtrl', function ($scope, $http, $location, CollectionService) {


            
            var retreiveCollection = function() {
                CollectionService.getCollection()
                    .then(function (collections) {
                       $scope.collections = collections.data;
                });
            };
            
            retreiveCollection();
            

            $scope.SelectedTable = "Please Select a Table";

            $scope.TableSelected = function(collection) {
                $scope.SelectedTable = collection;
                CollectionService.setTable(collection);
                var type = CollectionService.getScreenType();
                
                $location.path("/FieldSelect");

            };
        });
   
})();
