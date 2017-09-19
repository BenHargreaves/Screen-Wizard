(function () {

    angular
        .module('ScreenWizard')
        .controller('TitleCtrl', TitleCtrl);

    TitleCtrl.$inject = ['$scope'];

    function TitleCtrl($scope) {
        $scope.title = '';

    }
})();
