const gulp = require('gulp');
const ngc = require('gulp-ngc');
 
gulp.task('ngc', () => {
    return ngc('tsconfig.aot.json');
});
 