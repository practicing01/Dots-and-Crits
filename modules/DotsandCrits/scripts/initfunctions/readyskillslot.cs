function readyskillslot(%barslot)
{
%barslot.skillstate=0;
if (isObject(%barslot.moduleid))
{
%barslot.moduleid.ScopeSet.setskillbaricon(%barslot);
}
}
