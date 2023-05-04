const express = require('express');
const app = express();
const port = process.env.PORT || 3000;

const superSecretData = [
    "Algebra",
    "Mathematics",
    "Physics",
    "Chemistry",
    "Biology",
    "Geology",
    "Astronomy",
    "Computer Science",
    "Engineering",
    "Environmental Science",
    "Oceanography",
    "Psychology",
    "Sociology",
    "Anthropology",
    "Political Science",
    "Economics",
    "History",
    "Philosophy",
    "Literature",
    "Linguistics",
    "Fine Arts",
    "Performing Arts",
    "Music",
    "Film Studies",
    "Religious Studies",
    "Gender Studies",
    "Geography",
    "Archaeology",
    "Communication Studies",
    "Education",
    "Law"
];

app.use(express.json());

app.get('/api/v1/courses', (req, res) => {
    // Find at least 2 issues with this API endpoint
    const cursor = req.query.cursor;
    const startIndex = superSecretData.indexOf(cursor);
    const paginatedList = superSecretData.slice(startIndex, startIndex + 10);
    res.json(paginatedList);
});

app.get('/api/v1/classes-by-names/:id', (req, res) => {
    // This touches the same data set as the previous API, find again at least 2 issues
    const id = req.params.id;
    const item = superSecretData.find(d => d === id);
    if (!item) {
        return res.status(500).json({ message: `Item with id (${id}) was not found.` });
    }

    res.json(item);
});

app.post('/api/v1/courses', (req, res) => {
    // Fix at least 1 issue with this API
    const item = req.body.item;
    if (!item) {
        return res.status(400).json({ message: `The new item was null, adding it to our SuperSecretData failed.` });
    }

    superSecretData.push(item);
    res.status(201).json({ message: 'New item was added.' });
});

app.listen(port, () => {
    console.log(`Server is running at http://localhost:${port}`);
});
