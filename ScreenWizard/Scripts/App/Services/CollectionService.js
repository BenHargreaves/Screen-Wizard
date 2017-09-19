angular
    .module('ScreenWizard')
    .factory('CollectionService', ['$http', function ($http) {
        var urlBase = 'http://localhost:52440/api';

        var getCollection = function () {
            return $http.get(urlBase + '/collections')
        };

        var selectedTable = {};
        var screenType = {};
        var Fields = [];
   

        function getFields(collection) {
            return $http.get(urlBase + "/" + collection + "/TESTfields")
                .then(function (response) {
                    return Fields = response.data;
                });
        };

        function setTable(table) {
            selectedTable = table;
        };

        function getTable() {
            return selectedTable;
        };
        
        function setScreenType(type) {
            screenType = type;
        };
        
        function getScreenType() {
            return screenType;
        };

        return {
            getFields : getFields,
            getCollection: getCollection,
            getTable: getTable,
            setTable: setTable,
            getScreenType: getScreenType,
            setScreenType: setScreenType
        };
    }]);