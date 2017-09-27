(function () {

    angular
        .module('ScreenWizard')
        .controller('GeneratedListScreenCtrl', function ($scope, $http, $window, FieldService)
        {
            var urlBase = ("http://localhost:52440/api/")
            var screenData = FieldService.getScreen();
            $scope.screenData = screenData;
            getCustomers();        
            
            function getCustomers() {
                $http.get(urlBase + "customer")
                    .then(function(response){
                        $scope.customers = response.data;
                    });
            };
        });
})();
