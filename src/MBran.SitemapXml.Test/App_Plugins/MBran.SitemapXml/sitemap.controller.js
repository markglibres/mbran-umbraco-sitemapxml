angular.module('umbraco')
    .controller('MBran.SitemapXml.SitemapController', function ($scope, $element, assetsService, angularHelper) {
        $scope.model.hideLabel = true;
        

        if (!$scope.model.value) {
            $scope.model.value = {};
        }
        $scope.model.value.priority = 3;
        $scope.frequencySlider = {};
        $scope.prioritySlider = {};

        $scope.clickFrequency = function(event) {

            var itemIndex = getItemIndex(event, $scope.frequencies);
            var sliderPosition = getSliderPosition(itemIndex, $scope.frequencies);
            setFrequencySliderPosition(sliderPosition);
        };

        $scope.clickPriority = function (event) {

            console.log(event.offsetX);
            var itemIndex = getItemIndex(event, $scope.priorities);
            var sliderPosition = getSliderPosition(itemIndex, $scope.priorities);
            
            setPrioritySliderPosition(sliderPosition);
        };

        $scope.isPriority = function(priority) {
            return $scope.model.value.priority === priority;
        }

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

            $scope.priorities = [];

            var priority = 0;
            while (priority < 1) {
                $scope.priorities.push({ value: priority, text: priority });
                priority = +(priority + 0.1).toFixed(2);
            }
            
                
            if (!$scope.model.value.frequency) {
                $scope.model.value.frequency = 2;
            }
            if (!$scope.model.value.priority) {
                $scope.model.value.priority = 0.5;
            }

            $scope.priority = $scope.model.value.priority;

            var defaultPosition = getSliderPosition($scope.model.value.frequency + 1, $scope.frequencies);
            setFrequencySliderPosition(defaultPosition);
        }

        function getItemIndex(event, sliderItems) {
            
            var itemPercent = 100 / sliderItems.length;
            var width = event.currentTarget.clientWidth;
            var clickedX = event.offsetX; //event.clientX - width - event.currentTarget.offsetLeft;
            console.log(clickedX);
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

        function setPrioritySliderPosition(position) {

            $scope.prioritySlider.left = position.left + '%';
            $scope.prioritySlider.right = position.right + '%';
        }

        init();

        function createPrioritySlider() {
            var slider = $element.find('.priority-slider-item').bootstrapSlider({
                ticks: "[1, 2, 3]",
                ticks_labels: '["short", "medium", "long"]',
                min:1,
                max:3,
                step:1,
                value: $scope.model.value.priority,
                tooltip:"hide"
            }).on('slideStop', function (e) {
                var value = e.value;
                angularHelper.safeApply($scope, function () {
                    $scope.model.value.priority = value;
                });
            }).data('slider');
        }

        assetsService
            .loadJs("~/Umbraco/lib/slider/js/bootstrap-slider.js")
            .then(function () {

                createPrioritySlider();

                $scope.model.value.priority.onValueChanged = function (newVal, oldVal) {
                    if (newVal != oldVal) {
                        createPrioritySlider();
                    }
                };

            });

    });