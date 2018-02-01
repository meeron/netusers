const path = require('path');
const webpack = require('webpack');
const bundleOutputDir = './wwwroot/dist';

module.exports = (env) => {
  return [{
    stats: { modules: false },
    entry: { 'main': './ClientApp/main.js' },
    resolve: {
      extensions: ['.js', '.vue'],
      alias: {
        'vue$': 'vue/dist/vue',
        '@': path.join(__dirname,'ClientApp')
      }
    },
    output: {
      path: path.join(__dirname, bundleOutputDir),
      filename: '[name].js',
      publicPath: '/dist/'
    },
    module: {
      rules: [
        { test: /\.vue$/, include: /ClientApp/, use: 'vue-loader' },
        { test: /\.js$/, include: /ClientApp/, use: 'babel-loader' }
      ]
    },
    plugins: [
      new webpack.SourceMapDevToolPlugin({
        filename: '[file].map', // Remove this line if you prefer inline source maps
        moduleFilenameTemplate: path.relative(bundleOutputDir, '[resourcePath]') // Point sourcemap entries to the original file locations on disk
      })
    ]      
  }];
};