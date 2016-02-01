if (VersionControl.createRepo(project))
{
    this.createLocalFile();
    Console.WriteLine("Local File Created");
    panel2.UseWaitCursor = true;
    
    //commit details accessed from version control and stored in Idictionary
    IDictionary<string, string> auditDetails = VersionControl.pushFile(filename, project, details);
    panel2.UseWaitCursor = false;
    Console.WriteLine("Pushed to GitHub");
    //to add bug
    this.addBug();
    Console.WriteLine("Added to Bug table");
    //MessageBox.Show(auditDetails["isEmpty"]);
    string msg = "";
    //if commit was made
    if (auditDetails["isEmpty"] != "True")
    {
        bugAudit["status"] = "Created";
        bugAudit["hash"] = auditDetails["hash"];
        bugAudit["contributor"] = auditDetails["contributor"];
        bugAudit["time"] = auditDetails["time"];
        bugAudit["details"] = details;
        bugAudit["filename"] = filename;
        //records insert to audit
        Audit audit = new Audit();
        audit.insertAudit(bugAudit);
        Console.WriteLine("Audit Added");
        msg = "pushed to GitHub and";
    }
    lblMessage.ForeColor = System.Drawing.Color.Green;
    lblMessage.Text = "Success! Your bug was " + msg + " added to Bugs";
    this.firstPage();
}