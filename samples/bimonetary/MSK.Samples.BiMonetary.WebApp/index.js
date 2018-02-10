import 'babel-polyfill';

// style-sheets & font using in global scope
import 'font-awesome/css/font-awesome.min.css';
import 'simple-line-icons/css/simple-line-icons.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import './ClientApp/public/server/styles/style.css';

// scan assets (style, JavaScript) in all modules
require('./modules/' + /^.*$/);