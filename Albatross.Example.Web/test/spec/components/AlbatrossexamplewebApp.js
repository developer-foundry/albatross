"use strict";

describe("Main", function () {
  var React = require("react/addons");
  var AlbatrossexamplewebApp, component;

  beforeEach(function () {
    var container = document.createElement("div");
    container.id = "content";
    document.body.appendChild(container);

    AlbatrossexamplewebApp = require("components/AlbatrossexamplewebApp.js");
    component = React.createElement(AlbatrossexamplewebApp);
  });

  it("should create a new instance of AlbatrossexamplewebApp", function () {
    expect(component).toBeDefined();
  });
});
