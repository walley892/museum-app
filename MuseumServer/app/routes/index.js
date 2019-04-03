const rootRoute = require('./root_route');
const uploadModelsRoute = require('./upload_artifacts');
const getModelsRoute = require('./get_models.js');
const getModelFileRoute = require('./get_model_files');
const getModelInfoRoute = require('./get_model_info');

module.exports = function(express, app) {
  rootRoute.route(express, app);
  uploadModelsRoute(express, app);
  getModelsRoute(express, app);
  getModelFileRoute(express, app);
  getModelInfoRoute(express, app);
  // Other routes groups could go here, in the future
};