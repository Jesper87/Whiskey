// Write your Javascript code.
var app = angular.module('myApp', []);

app.controller('myController', ['$scope', 'whiskeyService', function ($scope, whiskeyService) {
	$scope.loading = true;

	$scope.edit = function (whiskey) {
		console.log("Edit clicked for " + whiskey.name);

	}

	var loadWhiskey = function () {
		whiskeyService.getWhiskey()
			.then(function (data) {
				$scope.whiskeys = data;
				$scope.loading = false;
			});
	}

	loadWhiskey();
}]);

app.service('whiskeyService', ['$http', function ($http) {
	this.getWhiskey = function () {
		return $http.get('http://localhost:55294/api/whiskey')
			.then(function (response) {
				var whiskeys = response.data;
				return whiskeys;
			});
	}
}]);