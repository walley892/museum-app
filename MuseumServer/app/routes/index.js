const rootRoute = require('./root_route');

module.exports = function(express, app) {
  rootRoute(express, app);
  // Other route groups could go here, in the future
};