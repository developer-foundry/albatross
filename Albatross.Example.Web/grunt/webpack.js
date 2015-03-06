"use strict";

var path = require("path"),
  CommonsChunkPlugin = require("webpack/lib/optimize/CommonsChunkPlugin");

var entry = {
    index: "client/js/pages/Index.jsx",
    anotherPage: "client/js/pages/AnotherPage.jsx"
};

var output = {
    path: "public/assets/js",
    filename: "[name].js"
};

var plugins = [
  new CommonsChunkPlugin("common.js") // Helps identify common parts of a require hierarchy
];

var ROOT = path.join(__dirname, 'client', 'js');

var webpackModules = {
    loaders: [
      { test: /\.js/, loader: 'jsx-loader?harmony' },
    ]
};

module.exports = {
    dev: {
        entry: entry,
        output: output,
        plugins: plugins,
        module: webpackModules,

        // Configure the console output
        stats: {
            colors: true,
            modules: true,
            reasons: true
        },
        progress: true,
        keepalive: true,
        watch: true,
        devtool: "source-map",
        bail: true,
        watchDelay: 3000,
        resolve: {
            extensions: ['', '.js', '.json', '.jsx'],
            root: ROOT,
            modulesDirectories: ['node_modules', 'components'],
            fallback: [path.join(__dirname, 'node_modules'), path.join(__dirname, 'client', 'components')]
        }
    }
};