﻿'use strict';

angular.module('antix.easi.examiners.create', [
        'antix.easi.examiners.api',
        'ui.bootstrap'
])
    .directive(
        'createExaminer', [
            '$log', '$http', '$modal',
            'ExaminersApi', 'ExaminerEvents',
            function (
                $log, $http, $modal,
                ExaminersApi, ExaminerEvents) {

                $log.debug('createExaminer.init');

                var modelContent;
                $http.get('examiners/create/examiners-create.cshtml')
                    .success(function (html) {
                        modelContent = html;
                    });

                return {
                    restrict: 'A',
                    replace: false,
                    scope: { createExaminer: '&' },
                    link: function (scope, element) {

                        $log.debug('createExaminer.link');

                        element.on('click', function () {

                            var modal = $modal.open({
                                template: modelContent,
                                scope: scope
                            });

                            scope.create = function (form, data) {

                                form.$setSubmitted();

                                ExaminersApi
                                    .create(data).$promise
                                    .then(function (createdModel) {

                                        scope.$root.$broadcast(ExaminerEvents.Created, createdModel);
                                        modal.close();

                                        if (scope.createExaminer) scope.createExaminer({ model: createdModel });
                                    })
                                    .catch(function (e) {
                                        $log.debug('createExaminer.ok() invalid ' + JSON.stringify(e.data));

                                        angular.forEach(e.data, function (error) {
                                            var split = error.split(':'),
                                                key = split[0][0].toLowerCase() + split[0].slice(1),
                                                validationType = split[1];

                                            $log.debug('invalid ' + key + ":" + validationType);

                                            form[key].$setValidity(validationType, false);
                                        });
                                    });
                            };

                            scope.cancel = function () {
                                modal.dismiss('cancel');
                            };
                        });

                    }
                };
            }
        ]);