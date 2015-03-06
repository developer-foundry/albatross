/*
 * Webpack development server configuration
 *
 * This file is set up for serving the webpack-dev-server, which will watch for changes and recompile as required if
 * the subfolder /webpack-dev-server/ is visited. Visiting the root will not automatically reload.
 */
"use strict";
var webpack = require("webpack");

module.exports = {

  output: {
    filename: "app.js",
    publicPath: "/assets/"
  },

  cache: true,
  debug: true,
  devtool: false,
  entry: [
      "webpack/hot/only-dev-server",
      "./src/scripts/app.js"
  ],

  stats: {
    colors: true,
    reasons: true
  },

  resolve: {
    extensions: ["", ".js", ".css", ".less"],
    alias: {
      "styles": "./src/styles",
      "components": "./src/scripts/components/"
    }
  },
  module: {
    preLoaders: [{
      test: /\.js$/,
      exclude: /node_modules/,
      loader: "jsxhint"
    }],
    loaders: [{
      test: /\.js$/,
      exclude: /node_modules/,
      loader: "react-hot!jsx-loader?harmony"
    }, {
      test: /\.less/,
      loader: "style-loader!css-loader!less-loader"
    }, {
      test: /\.css$/,
      loader: "style-loader!css-loader"
    }, {
      test: /\.(png|jpg)$/,
      loader: "url-loader?limit=8192"
    }]
  },

  plugins: [
    new webpack.HotModuleReplacementPlugin(),
    new webpack.NoErrorsPlugin()
  ]

};
