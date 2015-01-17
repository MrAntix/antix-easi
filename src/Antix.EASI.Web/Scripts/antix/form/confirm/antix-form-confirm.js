'use strict';

angular.module('antix.form.confirm', ['ui.bootstrap'])
    .directive(
        'aConfirm', [
            '$http', '$modal', 
            function ($http, $modal) {

                var modelContent;
                $http.get('/scripts/antix/form/confirm/antix-form-confirm.html')
                    .success(function(html) {
                        modelContent = html;
                    });

                return {
                    restrict: 'A',
                    replace: false,
                    scope: { aConfirm: '&' },
                    link: function (scope, element, attrs) {

                        element.on('click', function () {
                            scope.messageText = attrs.aConfirmMessage
                                || "Are you sure?";
                            scope.okText = attrs.aConfirmOk
                                || "OK";
                            scope.cancelText = attrs.aConfirmCancel
                                || "Cancel";

                            var modal = $modal.open({
                                template: modelContent,
                                scope:scope
                            });

                            scope.ok = function() {
                                scope.aConfirm();
                                modal.close();
                            };

                            scope.cancel = function() {
                                modal.dismiss('cancel');
                            };
                        });

                    }
                };
            }
        ]);

