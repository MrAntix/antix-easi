'use strict';

angular.module('antix.easi.examiners.api', [
        'ngResource'
    ])
    .factory(
        'ExaminersApi',
        [
            '$resource',
            function(
                $resource) {

                return $resource('/api/examiners/', {}, {
                    lookup: {
                        method: 'GET',
                        url: '/api/examiners/',
                        isArray: true
                    },
                    create: {
                        method: 'POST',
                        url: '/api/examiners/'
                    },
                    read: {
                        method: 'GET',
                        url: '/api/examiners/:id'
                    },
                    update: {
                        method: 'PUT',
                        url: '/api/examiners/:id',
                        params: { id: '@id' }
                    },
                    'delete': {
                        method: 'DELETE',
                        url: '/api/examiners/:id'
                    }
                });
            }
        ]);
