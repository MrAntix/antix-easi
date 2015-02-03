'use strict';

angular.module('antix.easi.patients.create', [
        'antix.easi.patients.api',
        'ui.bootstrap'
])
    .directive(
        'createPatient', [
            '$log', '$http', '$modal',
            'PatientsApi', 'PatientEvents',
            function (
                $log, $http, $modal,
                PatientsApi, PatientEvents) {

                $log.debug('createPatient.init');

                var modelContent;
                $http.get('patients/create/patients-create.cshtml')
                    .success(function (html) {
                        modelContent = html;
                    });

                return {
                    restrict: 'A',
                    replace: false,
                    scope: { createPatient: '&' },
                    link: function (scope, element) {

                        $log.debug('createPatient.link');

                        element.on('click', function () {

                            var modal = $modal.open({
                                template: modelContent,
                                scope: scope
                            });

                            scope.create = function (form, data) {

                                form.$setSubmitted();

                                PatientsApi
                                    .create(data).$promise
                                    .then(function (createdModel) {

                                        scope.$root.$broadcast(PatientEvents.Created, createdModel);
                                        modal.close();

                                        if (scope.createPatient) scope.createPatient({ model: createdModel });
                                    })
                                    .catch(function (e) {
                                        $log.debug('createPatient.ok() invalid ' + JSON.stringify(e.data));

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