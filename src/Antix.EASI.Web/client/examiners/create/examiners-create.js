'use strict';

angular.module('antix.easi.examiners.create', [
        'antix.easi.examiners.api'
])
    .controller(
        'AntixEASIExaminersCreateController',
        [
            '$log', '$scope', '$state',
            'ExaminersApi', 'ExaminerEvents',
            function (
                $log, $scope, $state,
                ExaminersApi, ExaminerEvents) {

                $log.debug('AntixEASIExaminersCreateController init');

                $scope.data = {};

                $scope.create = function () {

                    ExaminersApi
                        .create($scope.data).$promise
                        .then(function (data) {

                            $scope.$root.$broadcast(ExaminerEvents.Created, data);
                            $state.go('examiners-edit', { id: data.id });
                        })
                        .catch(function (e) {
                            $log.debug('AntixEASIExaminersCreateController create invalid ' + JSON.stringify(e.data));

                            angular.forEach(e.data, function (error) {
                                var split = error.split(':'),
                                    key = split[0][0].toLowerCase() + split[0].slice(1),
                                    validationType = split[1];

                                $log.debug('invalid ' + key + ":" + validationType);

                                $scope.form[key].$setValidity(validationType, false);
                            });
                        });
                };
            }
        ]);