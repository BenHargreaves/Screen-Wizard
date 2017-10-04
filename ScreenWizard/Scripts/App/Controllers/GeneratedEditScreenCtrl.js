(function () {

    angular
        .module('ScreenWizard')
        .controller('GeneratedEditScreenCtrl', function ($scope, $http, $window, FieldService)
        {
            var urlBase = ("http://localhost:52440/api/")
            var screenData = FieldService.getScreen();
            $scope.screenData = screenData;
            

            $scope.reset = function(){
                for (var i = 0; i < $scope.screenData.Fields.length; i++) {                   
                    $scope.screenData.Fields[i].Value = "";
                };
                $scope.screenSubmit.$setUntouched();
                $scope.screenSubmit.$setPristine();
            };

            $scope.submit = function () {
                var data = {};
                for (var i = 0; i < $scope.screenData.Fields.length; i++) {
                    if ($scope.screenData.Fields[i].Name != 'List') {
                        var name = $scope.screenData.Fields[i].Name;
                        var value = $scope.screenData.Fields[i].Value;
                        data[name] = value;
                    }
                    else {

                    }
                };
                $http.put(urlBase + $scope.screenData.TableName + "/create", data)
                    .then (function(response){
                        $window.alert($scope.screenData.TableName + " successfully created!");
                    });
            };
        });
})();
