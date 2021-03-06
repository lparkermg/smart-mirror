module.exports = function(grunt) {
    grunt.initConfig({
        pkg: grunt.file.readJSON('package.json'),
        clean: ["build", "dist"],
        uglify: {
            release: {
                options: {
                    report: 'gzip'
                },
                files: [{
                    expand: true,
                    src: 'js/*.js',
                    dest: 'dist/'
                }]
            }
        },
        jshint: {
            files: ['Gruntfile.js', 'js/*.js', 'main.js'],
            options: {
                globals: {
                    define: true,
                    document: true,
                    module: true,
                    console: true,
                    jQuery: true
                }
            }
        },
        copy: {
            css: {
                files: [{ expand:true, src: ['styles/*.css'], dest: 'dist/' }]
            },
            js: {
                files: [{ expand: true, src: ['js/*.html'], dest: 'dist/'}]
            },
            libs: {
                files: [{ expand:true, src: ['libs/*.js'], dest: 'dist/' }]
            },
            html: {
                files: [{ expand: true, src: ['index.html'], dest: 'dist/'}]
            },
            fonts: {
                files: [{ expand:true, src: ['font/*.ttf'], dest: 'dist/'}]
            }
        },
        zip: {
            'dist': {
                cwd: 'dist/',
                src: ['dist/*'],
                dest: 'dist/web-ui.zip'
            }
        },
        connect: {
            server: {
                options: {
                    port: 9999,
                    livereload: true,
                    base: 'dist'
                }
            }
        },
        watch: {
            js: {
                files: ['js/*.js'],
                tasks: [ 'jshint', 'uglify', 'copy:libs', 'copy:js' ]
            },
            styles: {
                files: 'styles/**/*.css',
                tasks: [ 'copy:css' ]
            },
            html: {
                files: ['*.html'],
                tasks: [ 'copy:html']
            },
            reload: {
                files: 'dist/**/*',
                options: {
                    livereload: true
                }
            }
        }
    });

    grunt.loadNpmTasks('grunt-contrib-uglify');
    grunt.loadNpmTasks('grunt-contrib-jshint');
    grunt.loadNpmTasks('grunt-contrib-concat');
    grunt.loadNpmTasks('grunt-contrib-watch');
    grunt.loadNpmTasks('grunt-contrib-connect');
    grunt.loadNpmTasks('grunt-contrib-copy');
    grunt.loadNpmTasks('grunt-contrib-clean');
    grunt.loadNpmTasks('grunt-zip');

    grunt.registerTask('build', ['clean','jshint', 'uglify', 'copy' ]);
    grunt.registerTask('serve', ['build', 'connect', 'watch']);
    grunt.registerTask('release', ['build', 'zip']);
    
    grunt.registerTask('default', ['build']);
};