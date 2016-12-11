const webpack = require("webpack");
const path = require("path");
const assets = path.join(__dirname, "wwwroot", "assets", "tests");
const glob = require("glob");

const entries = {};
var files = [];
files = files.concat(glob.sync("./src/**/*.specs.ts"));

files.forEach(file => {
    //var name = file.match("\.\/(?:Features|src\/script)(.+\/[^\/]+)\.ts?")[1];
    //entries[name] = file;
    //console.log(file);
});

module.exports = {
    resolve: {
        extensions: ['.ts', '.js']
    },
    entry: {
        'store': './src/app/utilities/store.specs'
    },
    output: {
        path: __dirname + "/tests",
        filename: "[name].js",
        publicPath: "tests/"
    },
    devtool: "source-map",
    module: {
        loaders: [
          { test: /\.ts$/, loaders: ['awesome-typescript-loader'], exclude: /node_modules/ }
        ]
    },
    plugins: [
    ]
};