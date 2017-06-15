const gulp = require('gulp');
const ngc = require('gulp-ngc');
const clean = require('gulp-clean');

gulp.task('clean',() => {
    return gulp.src('dist/**/*.*', { read: false })
        .pipe(clean());
});

gulp.task('ngc', () => {
    return ngc('tsconfig.aot.json');
});
 
gulp.task('copy', () => {
    gulp.src('./src/**/*.{css,html}')
    .pipe(gulp.dest('./dist'));
});

gulp.task('default',() => {
    return gulp.watch('./src/**/*.{css,html,ts}', ['clean','ngc','copy']);
});