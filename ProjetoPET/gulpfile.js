var gulp = require('gulp');
var concat = require('gulp-concat');
var uglify = require('gulp-uglify');
var sass = require('gulp-sass');
var cssmin = require('gulp-cssmin');

var paths = {
    webroot: "./wwwroot/",
    nodeModules: "./node_modules/"
};


//Dependencias de biblioteca javascript
//paths.jqueryjs = paths.nodeModules + "jquery/dist/jquery.js";
paths.jqueryjs = paths.nodeModules + "**/*js";
//paths.jqueryui = paths.nodeModules + "jquery/dist/jquery.js";


paths.destinationjsFolder = paths.webroot + "scripts/";
paths.vendorjsFileName = "vendor.min.js";
paths.jsFiles = "./Scripts/*.js";
paths.jsFileName = "script.min.js";



//Dependencias de SASS 
paths.sassFiles = paths.nodeModules + "**/*.scss";
paths.compiledCssFileName = "main.min.css";

//Dependencias de CSS
paths.bootstrap = paths.nodeModules + "**/*.css";
paths.vendorCssFileName = "vendor.min.css";


paths.destinationCssFolder = paths.webroot + "css/";


gulp.task("min:js", function () {
    return gulp.src(paths.jqueryjs)
        .pipe(concat(paths.vendorjsFileName))
        .pipe(uglify())
        .pipe(gulp.dest(paths.destinationjsFolder));
});

gulp.task("min:css", function () {
    return gulp.src(paths.bootstrap)
        .pipe(concat(paths.vendorCssFileName))
        .pipe(cssmin())
        .pipe(gulp.dest(paths.destinationCssFolder));
});


gulp.task("min:scss", function () {
    return gulp.src(paths.sassFiles)
        .pipe(sass().on('error', sass.logError))
        .pipe(concat(paths.compiledCssFileName))
        .pipe(cssmin())
        .pipe(gulp.dest(paths.destinationCssFolder));
});

gulp.task("watcher-js", function () {
    gulp.watch('./node_modules/**/*.js', gulp.series("min:js"));
});

gulp.task("watcher-sass", function () {
    gulp.watch('./node_modules/**/*.scss', gulp.series("min:scss"));
});
