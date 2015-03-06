"use strict";

var AlbatrossexamplewebApp = require("./AlbatrossexamplewebApp");
var React = require("react");
var Router = require("react-router");
var Route = Router.Route;

var content = document.getElementById("content");

var Routes = (
  <Route handler={AlbatrossexamplewebApp}>
    <Route name="/" handler={AlbatrossexamplewebApp}/>
  </Route>
);

Router.run(Routes, function (Handler) {
  React.render(<Handler/>, content);
});
