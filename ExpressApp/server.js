'use strict';

const express = require('express');
const app = express();

app.get('/', (req, res) => { res.send('Welcome to Node framework Express'); })
app.listen(3000, () => console.log('Working'))
