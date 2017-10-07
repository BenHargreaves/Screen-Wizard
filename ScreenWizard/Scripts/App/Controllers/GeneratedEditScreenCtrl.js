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

            $scope.Items = [];

            $scope.addRow = function () {
                var row = {};
                for (var j = 0; j < $scope.screenData.Fields.length; j++) {
                    if ($scope.screenData.Fields[j].Type == 'List') {
                        for (var i = 0; i < $scope.screenData.Fields[j].ItemDetails.length; i++) {
                            var name = $scope.screenData.Fields[j].ItemDetails[i].Name;
                            var value = $scope.screenData.Fields[j].ItemDetails[i].Value;
                            if (name == 'Subtotal') {
                                var rate = row['Price'] * row['Quantity'];
                                var discount = rate * (row['Discount'] / 100);
                                var value = ( rate - discount );
                            };
                            row[name] = value;
                        };
                        $scope.Items.push(row);
                    };
                };
            };

            $scope.submit = function () {
                var data = {};
                for (var i = 0; i < $scope.screenData.Fields.length; i++) {
                    if ($scope.screenData.Fields[i].Type != 'List') {
                        var name = $scope.screenData.Fields[i].Name;
                        var value = $scope.screenData.Fields[i].Value;
                        data[name] = value;
                    }
                    else {
                        var name = $scope.screenData.Fields[i].Name;
                        data[name] = $scope.Items;
                    };
                };
                $http.put(urlBase + $scope.screenData.TableName + "/create", data)
                    .then (function(response){
                        $window.alert($scope.screenData.TableName + " successfully created!");
                    });
            };
        });
})();
