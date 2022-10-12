module.exports = {
    prefix: '',
    content: [
      './src/**/*.{html,ts}',
    ],
    theme: {
      extend: {},
    },
    variants: {
      extend: {},
    },
    plugins: [require('@tailwindcss/forms'),require('@tailwindcss/typography')],
};