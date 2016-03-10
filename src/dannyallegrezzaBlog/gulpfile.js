/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp');

gulp.task('default', function () {
    /////// This is an example of how we could move items from one folder to another 
    /////// ex: files are in bower_components/* and need to go into wwwroot/lib

    /*
    gulp.src([
        'bower_components/jquery/dist/jquery.min.js',
        'bower_components/bootstrap/dist/js/bootstrap.min.js',
        'bower_components/bootstrap/dist/css/bootstrap.min.css'
    ])
    .pipe(gulp.dest('wwwroot/lib'))
    */
});