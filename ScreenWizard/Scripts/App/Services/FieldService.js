angular
    .module('ScreenWizard')
    .factory('FieldService', ['$http', function ($http) {
        
        var selectedFields = [];
        var selectedScreen = [];

        function setPreviewFields(fields) {
            selectedFields = fields;
        };

        function getPreviewFields() {
            return selectedFields;
        };

        function setScreen(screen) {
            selectedScreen = screen;
        };

        function getScreen() {
            return selectedScreen;
        };


        return {
            getPreviewFields: getPreviewFields,
            setPreviewFields: setPreviewFields,
            getScreen: getScreen,
            setScreen: setScreen
        };
    }]);