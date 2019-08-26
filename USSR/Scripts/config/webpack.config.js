const path = require("path");

module.exports = {
    entry: {
        index: "./Scripts/src/index.js"
    },
    output: {
        path: path.resolve(__dirname, "../dist"),
        filename: "[name].js"
    },
    module: {
        rules: [
            {
                use: {
                    loader: "babel-loader"
                },
                test: /\.js$/,
                exclude: /node_modules/ 
            },
          {
              test: /\.css$/,
              loader:[ 'style-loader', 'css-loader' ]
            },
            {
                test: /\.(png|jpg)$/,
                loader: 'url-loader'
            }]
         }
}