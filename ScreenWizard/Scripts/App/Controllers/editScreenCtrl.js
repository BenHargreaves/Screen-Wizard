(function () {


    angular.module('ScreenWizard')

        .controller('EditCtrl', function ($scope, $http, CollectionService, FieldService) {
            $scope.table = CollectionService.getTable();
            $scope.previewFields = FieldService.getPreviewFields();            
            var urlBase = 'http://localhost:52440/api/screen';


            
            $scope.saveScreen = function(screenCaption, tablename, fields){
                var screenMetadata = {
                    "ScreenCaption" : screenCaption,
                    "TableName" : tablename,
                    "ScreenType" : "Edit",
                    "Fields" : fields
                };
                $http.put(urlBase, screenMetadata);
            

            };

            
        });




})();
