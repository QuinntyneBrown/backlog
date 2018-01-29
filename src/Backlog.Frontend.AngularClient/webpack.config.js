const webpack = require('webpack');
const CommonsChunkPlugin = webpack.optimize.CommonsChunkPlugin;
const UglifyJsPlugin = require('uglifyjs-webpack-plugin');

module.exports = {
    entry: {
        'vendor': ['./src/polyfills'],
        'app': './src/main'
    },
    output: {
        path: __dirname + "/dist",
        filename: "[name].js",
        publicPath: "dist/"
    },
    resolve: {
        extensions: ['.ts', '.css', '.html', '.js']
    },
    module: {
        loaders: [
            {
                test: /\.ts$/,
                use: [{
                    loader: 'awesome-typescript-loader'
                }, {
                    loader: 'angular-router-loader'
                },
                {
                    loader: 'angular2-template-loader'
                }]
            },
            { test: /\.css$/, loader: 'raw-loader' },
            { test: /\.html$/, loaders: ['html-loader'] },
        ]
    },
    plugins: [
        new UglifyJsPlugin({
            uglifyOptions: {
                ie8: false,
                ecma: 8,
                output: {
                    comments: false,
                    beautify: false
                },
                compress: { },
                warnings: false
            }
        })
    ]
};
