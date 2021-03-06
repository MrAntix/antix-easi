﻿'use strict';

angular.module('antix.easi.examinations.create', [
        'antix.easi.examinations.api'
])
    .controller(
        'AntixEASIExaminationsCreateController',
        [
            '$log', '$scope', '$state',
            'ExaminationsApi', 'ExaminationEvents',
            function (
                $log, $scope, $state,
                ExaminationsApi, ExaminationEvents) {

                $log.debug('AntixEASIExaminationsCreateController init');

                $scope.data = {
                    takenOn: new Date()
                };

                $scope.create = function () {

                    ExaminationsApi
                        .create({
                            takenOn: $scope.data.takenOn,
                            patientId: $scope.data.patient && $scope.data.patient.id,
                            examinerId: $scope.data.examiner && $scope.data.examiner.id
                        }).$promise
                        .then(function (data) {

                            $scope.$root.$broadcast(ExaminationEvents.Created, data);
                            $state.go('examinations-edit', { id: data.id });
                        })
                        .catch(function (e) {
                            $log.debug('AntixEASIExaminationsCreateController create invalid ' + JSON.stringify(e.data));

                            $scope.form.$setSubmitted();
                            $scope.form.$setValidity();

                            angular.forEach(e.data, function (error) {
                                var split = error.split(/[\[:]/),
                                    key = split[0][0].toLowerCase() + split[0].slice(1),
                                    validationType = split[1];

                                $log.debug('invalid ' + key + ":" + validationType);

                                $scope.form[key].$setValidity(validationType, false);
                            });
                        });
                };
            }
        ]);