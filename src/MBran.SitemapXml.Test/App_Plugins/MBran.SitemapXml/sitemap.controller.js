angular.module('umbraco')
    .controller('MBran.SitemapXml.SitemapController', function ($scope) {
        alert('test');
        if (!$scope.model.value) {
            $scope.model.value = {};
        }
});