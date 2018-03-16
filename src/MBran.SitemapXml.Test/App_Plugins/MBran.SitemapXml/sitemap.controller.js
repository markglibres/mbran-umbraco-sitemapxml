angular.module('umbraco')
    .controller('MBran.SitemapXml.SitemapController', function ($scope) {
        $scope.model.hideLabel = true;

        if (!$scope.model.value) {
            $scope.model.value = {};
        }
        $scope.slider = {};

        $scope.clickFrequency = function(event) {

            var itemIndex = getItemIndex(event);
            var sliderPosition = getSliderPosition(itemIndex);
            setSliderPosition(sliderPosition);
        };

        function init() {
            $scope.frequencies = [
                { value: 0, text: 'Always' },
                { value: 1, text: 'Hourly' },
                { value: 2, text: 'Daily' },
                { value: 3, text: 'Weekly' },
                { value: 4, text: 'Monthly' },
                { value: 5, text: 'Yearly' },
                { value: 6, text: 'Never' },
            ];

            $scope.itemPercent = 100 / $scope.frequencies.length;

            var defaultPosition = getSliderPosition(3);
            setSliderPosition(defaultPosition);
        }

        function getItemIndex(event) {
            
            var width = event.currentTarget.clientWidth;
            var clickedX = event.clientX - width - event.currentTarget.offsetLeft;
            var clickedPercentage = (clickedX / width) * 100;
            var itemIndex = Math.ceil(clickedPercentage / $scope.itemPercent);
            return itemIndex;
        }

        function getSliderPosition(itemIndex) {

            var left = (itemIndex * $scope.itemPercent) - ($scope.itemPercent / 2);
            return {
                left: left,
                right: 100-left
            };
        }

        function setSliderPosition(position) {

            $scope.slider.left = position.left + '%';
            $scope.slider.right = position.right + '%';
        }

        init();
    });