(function () {

    angular.module('ScreenWizard')

        .controller('ListScreenCtrl', function ($scope, $http, $window, $location, CollectionService, FieldService) {
            $scope.table = CollectionService.getTable();
            $scope.previewFields = FieldService.getPreviewFields();            
            var urlBase = 'http://localhost:52440/api/';
            getCustomers();

            $scope.saveScreen = function(screenCaption, tablename, fields){
                var screenMetadata = {
                    "ScreenCaption" : screenCaption,
                    "TableName" : tablename,
                    "ScreenType" : "List",
                    "Fields" : fields
                };
                $http.put(urlBase + "screen", screenMetadata);
                $window.alert("Succes! New List screen created");
                $location.path('/');
                };
           
            
            function getCustomers() {
                $http.get(urlBase + "customer")
                    .then(function(response){
                        $scope.customers = response.data;
                    });
            };
        });

})();