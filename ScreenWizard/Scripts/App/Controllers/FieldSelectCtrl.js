(function () {

    angular.module('ScreenWizard')

        .controller('FieldSelectCtrl', function ($scope, $http, $location, CollectionService, FieldService) {
            var table = CollectionService.getTable();
            $scope.table = table;
            
            var screenType = CollectionService.getScreenType();

            var response = CollectionService.getFields(table);

            response.then(function (result) {
                $scope.Fields = result;
                for(i=$scope.Fields.length - 1 ; i>0 ; i--) { 
                  if ($scope.Fields[i].IsRequired) {
                    $scope.selectFieldForScreen($scope.Fields[i]);
                  }
                }
            });


            $scope.SelectedFields = [];

            $scope.setPreviewFields = function(fields) {
                FieldService.setPreviewFields(fields);
                $location.path("/" + screenType);
            };
        
            

            $scope.selectFieldForScreen = function(Field){
                $scope.SelectedFields.push(Field);
                $scope.Fields.splice($scope.Fields.indexOf(Field), 1);

            };

            $scope.removeFieldFromList = function (SelectedField) {
                $scope.Fields.push($scope.SelectedFields[$scope.SelectedFields.indexOf(SelectedField)]);
                $scope.SelectedFields.splice($scope.SelectedFields.indexOf(SelectedField), 1);

            };
            
            });

})();
