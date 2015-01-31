'use strict';

angular.module('antix.easi.examiners.select', [
        'antix.easi.examiners.api',
        'antix.easi.examiners.create'
])
    .directive(
        'examinersSelect',
        [
            '$log',
            'ExaminersApi',
            function (
                $log,
                ExaminersApi) {

                $log.debug('examinersSelect init');

                return {
                    restrict: 'EA',
                    replace: true,
                    templateUrl: 'examiners/select/examiners-select.cshtml',
                    scope: {
                        'examinerId': '=ngModel'
                    },
                    link: function ($scope, element, attrs) {
                        $log.debug('examinersSelect link');

                        $scope.get = function (filter) {
                            return ExaminersApi.lookup({
                                filter: filter,
                                limitTo: 8
                            }).$promise
                                .then(function (data) {
                                    $log.debug('examinersSelect.lookup ' + JSON.stringify(data));

                                    return $scope.data = data;
                                });
                        };

                        $scope.select = function (data) {
                            $log.debug('examinersSelect.select(' + JSON.stringify(data) + ')');
                            
                            $scope.data = [data];
                            $scope.examinerId = data.id;
                        };

                        $scope.format = function (id) {
                            $log.debug('examinersSelect.format(' + id + ')');

                            if (!$scope.data) return;
                            for (var i = 0; i < $scope.data.length; i++)
                                if (id === $scope.data[i].id) return $scope.data[i].name;
                        };
                    }
                };
            }
        ]);