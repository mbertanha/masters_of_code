module.exports = function(grunt) {
  grunt.config('browserSync', {
    build: {
      options: {
        server: {
          baseDir: "../"
        },
        port: 82
      }
    }
  });
}