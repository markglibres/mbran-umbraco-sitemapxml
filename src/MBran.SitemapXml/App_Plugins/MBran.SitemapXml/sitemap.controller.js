angular.module('umbraco')
    .controller('MBran.SitemapXml.SitemapController', function ($scope) {
        $scope.model.hideLabel = true;

        if (!$scope.model.value) {
            $scope.model.value = {};
        }
        $scope.frequencySlider = {};

        $scope.clickFrequency = function(event) {

            var itemIndex = getItemIndex(event, $scope.frequencies);
            var sliderPosition = getSliderPosition(itemIndex, $scope.frequencies);
            setFrequencySliderPosition(sliderPosition);
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


            var defaultPosition = getSliderPosition(3, $scope.frequencies);
            setFrequencySliderPosition(defaultPosition);
        }

        function getItemIndex(event, sliderItems) {
            
            var itemPercent = 100 / sliderItems.length;
            var width = event.currentTarget.clientWidth;
            var clickedX = event.clientX - width - event.currentTarget.offsetLeft;
            var clickedPercentage = (clickedX / width) * 100;
            var itemIndex = Math.ceil(clickedPercentage / itemPercent);
            return itemIndex;
        }

        function getSliderPosition(itemIndex, sliderItems) {

            var itemPercent = 100 / sliderItems.length;
            var left = 0;
            if (itemIndex === sliderItems.length) left = 100;
            else if (itemIndex > 0) left = (itemIndex * itemPercent) - (itemPercent / 2);

            return {
                left: left,
                right: 100-left
            };
        }

        function setFrequencySliderPosition(position) {

            $scope.frequencySlider.left = position.left + '%';
            $scope.frequencySlider.right = position.right + '%';
        }

        init();
    });