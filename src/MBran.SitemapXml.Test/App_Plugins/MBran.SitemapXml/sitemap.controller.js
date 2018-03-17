angular.module('umbraco')
    .controller('MBran.SitemapXml.SitemapController', function ($scope, $element, assetsService, angularHelper) {
        
        
        function init() {

            initOptions();
            initModel();
            initSliders();
        }
        
        init();

        function initOptions() {
            $scope.model.hideLabel = true;
            $scope.frequencies = ['Always', 'Hourly', 'Daily', 'Weekly', 'Monthly', 'Yearly', 'Never'];
        }

        function initModel() {
            if (!$scope.model.value) {
                $scope.model.value = {};
            }

            $scope.model.value.priority = $scope.model.value.priority ? parseFloat($scope.model.value.priority) : 0.5;
            $scope.model.value.frequency = $scope.model.value.frequency ? parseInt($scope.model.value.frequency) : 2;
        }

        function initSliders() {
            assetsService
                .loadJs("~/Umbraco/lib/slider/js/bootstrap-slider.js")
                .then(function () {

                    createFrequencySlider();
                    $scope.model.value.frequency.onValueChanged = function (newVal, oldVal) {
                        if (newVal !== oldVal) {
                            createFrequencySlider();
                        }
                    };

                    createPrioritySlider();
                    $scope.model.value.priority.onValueChanged = function (newVal, oldVal) {
                        if (newVal !== oldVal) {
                            createPrioritySlider();
                        }
                    };

                });

            assetsService.loadCss("~/Umbraco/lib/slider/bootstrap-slider.css");
            assetsService.loadCss("~/Umbraco/lib/slider/bootstrap-slider-custom.css");
        }

        function createPrioritySlider() {

            $element.find('.priority-slider-item').bootstrapSlider({
                min: 0,
                max: 1,
                step: 0.1,
                value: $scope.model.value.priority,
                tooltip: "always",
                precision: 1
            }).on('slideStop', function (e) {
                var value = e.value;
                angularHelper.safeApply($scope, function () {
                    $scope.model.value.priority = value;
                });
            }).data('slider');
        }

        function createFrequencySlider() {

            var ticks = [];
            
            window.angular.forEach($scope.frequencies, function (value, key) {
                ticks.push(key);
            });
            
            $element.find('.frequency-slider-item').bootstrapSlider({
                ticks: ticks,
                ticks_labels: $scope.frequencies,
                min: ticks[0],
                max: ticks[ticks.length-1],
                step: 1,
                value: $scope.model.value.frequency,
                tooltip: "hide"
            }).on('slideStop', function (e) {
                var value = e.value;
                angularHelper.safeApply($scope, function () {
                    $scope.model.value.frequency = value;
                });
            }).data('slider');
        }
    });