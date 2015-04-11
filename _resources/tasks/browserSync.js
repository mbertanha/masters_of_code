module.exports = function(grunt) {
  grunt.config('browserSync', {
    build: {
      bsFiles: {
        src : '../css/*.css'
      },
      options: {
        server: {
          baseDir: "../"
        },
        port: 82
      }
    }
  });
}