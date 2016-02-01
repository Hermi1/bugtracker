//empty
if (VersionControl.createRepo(project))
{
    this.createLocalFile();
    Console.WriteLine("Local File Created");
    panel2.UseWaitCursor = true;
    IDictionary<string, string> auditDetails = VersionControl.pushFile(filename, project, details);
    panel2.UseWaitCursor = false;
    
    
    Console.WriteLine("Pushed to GitHub");
    this.updateBug();
    Console.WriteLine("Added to Bug table");
    //MessageBox.Show(auditDetails["isEmpty"]);
    if (auditDetails["isEmpty"] != "True")
    {
        bugAudit["status"] = "Updated";
        bugAudit["hash"] = auditDetails["hash"];
        bugAudit["contributor"] = auditDetails["contributor"];
        bugAudit["time"] = auditDetails["time"];
        bugAudit["details"] = details;
        bugAudit["filename"] = filename;
        Audit audit = new Audit();
        audit.insertAudit(bugAudit);
        Console.WriteLine("Audit Added");
    }
    lblMessage.ForeColor = System.Drawing.Color.Green;
    lblMessage.Text = "Success! Your bug was pushed to GitHub and added to Bugs";
    this.firstPage();
}