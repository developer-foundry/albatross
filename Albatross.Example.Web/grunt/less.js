"use strict";

module.exports = {
    development: {
        options: {
            cleancss: false
        },

        files: [{
            expand: true,
            cwd: "client/less",
            src: ["**/*.less"],
            dest: "public/assets/css/",
            ext: ".css"
        }]
    }
};