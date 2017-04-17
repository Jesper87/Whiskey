// Write your Javascript code.
var app = angular.module('myApp', []);

app.controller('myController', ['$scope', 'whiskeyService', function ($scope, whiskeyService) {
	$scope.loading = true;

	var loadWhiskey = function () {
		whiskeyService.getWhiskey()
			.then(function (data) {
				$scope.whiskeys = data;
				$scope.loading = false;
			});
	}

	var addWhiskey = function (data) {
		whiskeyService.addWhiskey(data)
			.then(function (response) {
				loadWhiskey();
				$scope.message = response.data;
				return;
			});
	}

	$scope.addWhiskey = function (form) {
		addWhiskey(form);
	};

	loadWhiskey();
}]);

app.service('whiskeyService', ['$http', function ($http) {

	this.getWhiskey = function () {
		return $http.get('api/whiskey')
			.then(function (response) {
				var whiskeys = response.data;
				return whiskeys;
			});
	}

	this.addWhiskey = function (data) {
		return $http.post('api/whiskey/', data)
			.then(function (response) {
				return response;
			});
	}
}]);