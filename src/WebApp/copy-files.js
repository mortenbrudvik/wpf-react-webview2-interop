const fs = require('fs-extra'); // Use 'fs' if you skip fs-extra
const path = require('path');

const sourceDir = path.resolve(__dirname, 'dist'); // Vite's default output folder
const targetDir = path.resolve(__dirname, 'path/to/your/target/folder'); // Change this to your desired folder

async function copyFiles() {
    try {
        // Ensure the target directory exists
        await fs.ensureDir(targetDir);
        // Copy all files from dist to the target folder
        await fs.copy(sourceDir, targetDir, { overwrite: true });
        console.log(`Files copied successfully from ${sourceDir} to ${targetDir}`);
    } catch (err) {
        console.error('Error copying files:', err);
        process.exit(1); // Exit with error code
    }
}

copyFiles();