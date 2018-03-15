angular.module('umbraco')
    .controller('MBran.SitemapXml.SitemapController', function ($scope) {
        if (!$scope.model.value) {
            $scope.model.value = {};
        }

        $scope.clickFrequency = function(event) {

            var x = event.offsetX ? event.offsetX : (event.originalEvent.layerX ? event.originalEvent.layerX : event.x);
            var y = event.offsetY ? event.offsetY : (event.originalEvent.layerY ? event.originalEvent.layerY : event.y);

            console.log(x, y);
        };
    });